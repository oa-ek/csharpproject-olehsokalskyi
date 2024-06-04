import React, {useState, useEffect} from 'react';
import useApi from "../hook/getData";
import {useForm} from "react-hook-form";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import Select from 'react-select';
import Form from 'react-bootstrap/Form';

export const FormComponent = ({ url, type, fields, show, handleClose, data }) => {
    const { register, handleSubmit, formState: { errors }, setValue } = useForm();
    const { createData, updateData, fetchData } = useApi(url);
    const [selectData, setSelectData] = useState({});

    const OnSubmit = data => {
        type === 'post' ? createData(data)   : updateData(data.id, data);
    }

    useEffect(() => {
        if (data && fields) {
            fields.forEach(field => {
                setValue(field.name, data[field.name]);
            });
        }
    }, [data, fields,]);

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
                                        <Form.Control type="text" {...register(field.name, {required: field.validator})} />
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