import React from 'react';
import Button from "react-bootstrap/Button";
import  Table from 'react-bootstrap/Table';
import FormComponent from '../components/FormComponent';

const TableComponent = ({ data, fields, handleShow1, handleShow2 }) => {
    return (
        <>
            <Table >
                <thead>
                <tr>
                    {fields && fields.map((field, index) => {
                        if (!field.isHide) {
                            return <td key={index}>{field.name}</td>
                        }
                        return null;
                    })}
                    <td>Edit</td>
                    <td>Delete</td>
                </tr>
                </thead>
                <tbody>
                {data && data.map((item) => (
                    <tr key={item.id}>
                        {fields && fields.map((field, index) => {
                            if (!field.isHide) {
                                return <td key={index}>{item[field.name]}</td>
                            }
                            return null;
                        })}
                        <td>
                            <Button variant="warning" onClick={() => handleShow1(item)}>
                                Edit
                            </Button>
                        </td>
                        <td>
                            <Button variant="danger" onClick={() => handleShow2(item.id)}>
                                Delete
                            </Button>
                        </td>
                    </tr>
                ))}
                </tbody>
            </Table >
        </>
    )
};

export default TableComponent;