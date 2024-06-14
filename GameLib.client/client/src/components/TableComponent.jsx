import React from 'react';
import Button from "react-bootstrap/Button";
import Table from 'react-bootstrap/Table';
import StarRatings from "react-star-ratings";

const TableComponent = ({ data, fields, handleShow1, handleShow2, disableEdit }) => {
    const renderField = (item, field) => {
        if (field.isStar) {
            return (
                <StarRatings
                    rating={parseFloat(item[field.name])}
                    starRatedColor="gold"
                    numberOfStars={5}
                    name='rating'
                    starDimension="20px"
                    starSpacing="2px"
                />
            );
        } //TODO треба передавати параметр щоб офати редагування рейтингу
        if (field.isObject && item[field.name]) {
            return field.objFields.map((subField, subIndex) => (
                <span key={subIndex}>{item[field.name][subField]}{subIndex < field.objFields.length - 1 ? ', ' : ''}</span>
            ));
        }
        return item[field.name];
    };

    return (
        <>
            <Table>
                <thead>
                <tr>
                    {fields && fields.map((field, index) => {
                        if (!field.isHide) {
                            return <td key={index}>

                                {field.label}</td>
                        }
                        return null;
                    })}
                    {!disableEdit && <td>Edit</td>}
                    <td>Delete</td>
                </tr>
                </thead>
                <tbody>
                {data && data.map((item) => (
                    <tr key={item.id}>
                        {fields && fields.map((field, index) => {
                            if (!field.isHide) {
                                return <td key={index}>{renderField(item, field)}</td>
                            }
                            return null;
                        })}
                        {!disableEdit && <td>
                            <Button variant="warning" onClick={() => handleShow1(item)}>
                                Edit
                            </Button>
                        </td>}

                        <td>
                            <Button variant="danger" onClick={() => handleShow2(item.id)}>
                                Delete
                            </Button>
                        </td>
                    </tr>
                ))}
                </tbody>
            </Table>
        </>
    )
};

export default TableComponent;
