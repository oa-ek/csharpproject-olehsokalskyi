import React, {useState, useEffect} from 'react';
import useApi from "../hook/getData";
import {useForm} from "react-hook-form";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import Select from 'react-select';
import Form from 'react-bootstrap/Form';
import axios from "axios";

export const FormComponent = ({ url, type, fields, show, handleClose, data}) => {
    const { register, handleSubmit, formState: { errors }, setValue } = useForm();
    const { createData, updateData, fetchData } = useApi();
    const [selectData, setSelectData] = useState({});

    const OnSubmit = data => {
        console.log(url)
        type === 'post' ? createData(url,data)   : updateData(url,data.id, data);
    }

    useEffect(() => {
        if (data && fields) {
            fields.forEach(field => {
                setValue(field.name, data[field.name]);
            });
        }
    }, [data, fields,]);

    useEffect(() => {
        fields.forEach(async field => {
            if (field.isSelect || field.isMultySelect) {
                console.log(field.entityurl)
                const response = await axios.get('https://localhost:7226/api/game/list')
                const data = response.data
                console.log(data)
                setSelectData(prevData => ({...prevData, [field.name]: data}));
            }
        });
    }, [fields]);

    return (
        <>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>{type === 'post' ? 'Create' : 'Edit'}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={handleSubmit(OnSubmit)}>
                        {fields && fields.map((field, index) => (
                            <Form.Group className="mb-3" key={index}>
                                {field.name !== 'id' || type !== 'post' ? (
                                    <React.Fragment>
                                        <Form.Label>{field.name}</Form.Label>
                                        {field.isSelect || field.isMultySelect ? (
                                            <Select
                                                options={selectData[field.name]?.map(item => ({
                                                    value: item.id,
                                                    label: field.visibleFields.map(f => item[f]).join(' ')
                                                }))}
                                                isMulti={field.isMultySelect}
                                                {...register(field.name, {required: field.validator})}
                                                onChange={option => {
                                                    if (field.isMultySelect) {
                                                        setValue(field.name, option.map(o => o.value));
                                                    } else {
                                                        setValue(field.name, option.value);
                                                    }
                                                }}

                                            />
                                        ) : (
                                            <Form.Control type="text" {...register(field.name, {required: field.validator})} />
                                        )}
                                    </React.Fragment>
                                ) : null}
                            </Form.Group>
                        ))}
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={() => {
                        handleSubmit(OnSubmit)();
                        handleClose();
                    }}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
};