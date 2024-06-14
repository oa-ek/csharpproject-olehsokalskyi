import React, {useState, useEffect} from 'react';
import useApi from "../hook/getData";
import {useForm} from "react-hook-form";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import Select from 'react-select';
import Form from 'react-bootstrap/Form';
import axios from "axios";
import EventBus from "../hook/eventBus";

export const FormComponent = ({ url, type, fields, show, handleClose, data }) => {
    const { register, handleSubmit, formState: { errors }, setValue, getValues } = useForm();
    const { createData, updateData, fetchData } = useApi();
    const [selectData, setSelectData] = useState({});
    const [selectedValues, setSelectedValues] = useState({});

    const OnSubmit = async data => {
        data.price = parseFloat(data.price);

        fields.forEach(field => {
            if (field.isMultySelect && !data[field.name]) {
                data[field.name] = [];
            }
        });

        console.log(data);
        if (type === 'post') {
            await createData(url, data);
            EventBus.emit('dataChanged', 'create');
        } else {
            await updateData(url, data.id, data);
            EventBus.emit('dataChanged', 'update');
        }
        handleClose();
    };

    useEffect(() => {
        fields.forEach(async field => {
            if (field.isSelect || field.isMultySelect) {
                const response = await axios.get(`https://localhost:7226/api/${field.entityurl}/list`);
                const data = response.data;
                setSelectData(prevData => ({ ...prevData, [field.name]: data }));
            }
        });
    }, [fields]);

    useEffect(() => {
        if (data && fields) {
            fields.forEach(field => {
                if (field.isSelect || field.isMultySelect) {
                    if (data[field.name]) {
                        const selectedValue = field.isMultySelect ? data[field.name].map(item => ({
                            value: item.id,
                            label: field.visibleFields.map(f => item[f]).join(' ')
                        })) : {
                            value: data[field.name].id,
                            label: field.visibleFields.map(f => data[field.name][f]).join(' ')
                        };
                        setSelectedValues(prevValues => ({ ...prevValues, [field.name]: selectedValue }));
                        setValue(field.name, selectedValue);
                    }
                } else if (data[field.name]) {
                    setValue(field.name, data[field.name]);
                }
            });
        }
    }, [data, fields, setValue]);

    const handleImageUpload = event => {
        const file = event.target.files[0];
        const reader = new FileReader();

        reader.onloadend = () => {
            setValue('imagePath', reader.result);
        };

        if (file) {
            reader.readAsDataURL(file);
        }
    };

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
                                                value={selectedValues[field.name]}
                                                onChange={option => {
                                                    if (field.isMultySelect) {
                                                        setValue(field.name, option.map(o => o.value));
                                                        setSelectedValues(prevValues => ({ ...prevValues, [field.name]: option }));
                                                    } else {
                                                        setValue(field.name, option.value);
                                                        setSelectedValues(prevValues => ({ ...prevValues, [field.name]: option }));
                                                    }
                                                }}
                                            />
                                        ) : field.isPhoto ? (
                                            <input type="file" accept="image/*" onChange={handleImageUpload} />
                                        ) : (
                                            <Form.Control type={field.isNumber ? 'number' : 'text'} {...register(field.name, { required: field.validator })} />
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
