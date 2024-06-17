import React from 'react';
import Button from "react-bootstrap/Button";
import Table from 'react-bootstrap/Table';
import StarRatings from "react-star-ratings";
import { useState, useEffect } from "react";

const TableComponent = ({ data, fields, handleShow1, handleShow2, disableEdit }) => {
    const [sortField, setSortField] = useState(null);
    const [sortDirection, setSortDirection] = useState('asc');
    const [searchQuery, setSearchQuery] = useState('');

    useEffect(() => {
        setSortField(null); // Скидаємо поле сортування при отриманні нових даних
        setSortDirection('asc');
    }, [data]);

    const handleSort = (field) => {
        const newSortDirection = (sortField === field && sortDirection === 'asc') ? 'desc' : 'asc';
        setSortField(field);
        setSortDirection(newSortDirection);
    };

    const handleSearch = (event) => {
        setSearchQuery(event.target.value);
    };

    if (!data) {
        return null; // Якщо дані ще не завантажилися, поки відображаємо нічого
    }

    const sortedData = sortField ? [...data].sort((a, b) => {
        if (a[sortField] < b[sortField]) {
            return sortDirection === 'asc' ? -1 : 1;
        }
        if (a[sortField] > b[sortField]) {
            return sortDirection === 'asc' ? 1 : -1;
        }
        return 0;
    }) : data;

    const filteredData = sortedData.filter(item =>
        Object.values(item).some(val =>
            String(val).toLowerCase().includes(searchQuery.toLowerCase())
        )
    );

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
        }
        if (field.isObject && item[field.name]) {
            return field.objFields.map((subField, subIndex) => (
                <span key={subIndex}>{item[field.name][subField]}{subIndex < field.objFields.length - 1 ? ', ' : ''}</span>
            ));
        }
        return item[field.name];
    };

    return (
        <>
            <input type="text" value={searchQuery} onChange={handleSearch} placeholder="Search..." />
            <Table>
                <thead>
                <tr>
                    {fields.map((field, index) => (
                        !field.isHide && (
                            <th key={index}>
                                <Button onClick={() => handleSort(field.name)}>
                                    {field.label}
                                </Button>
                            </th>
                        )
                    ))}
                    {!disableEdit && <th>Edit</th>}
                    <th>Delete</th>
                </tr>
                </thead>
                <tbody>
                {filteredData.map((item) => (
                    <tr key={item.id}>
                        {fields.map((field, index) => (
                            !field.isHide && <td key={index}>{renderField(item, field)}</td>
                        ))}
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
    );
};

export default TableComponent;
