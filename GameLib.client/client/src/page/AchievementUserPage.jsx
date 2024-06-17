import React, { useState, useEffect } from 'react';
import useApi from '../hook/getData';
import EventBus from '../hook/eventBus';
import TableComponent from '../components/TableComponent';
import { displayFields } from '../datadef/datadef';
import DeleteModal from '../components/ModalDeleteObject';

export const AchievementUserPage = () => {
    const { data, fetchData, message, deleteData } = useApi('https://localhost:7226/api/achievementUser/list');
    const [deleteShow, setDeleteShow] = useState(false);
    const [deleteId, setDeleteId] = useState(null);
    const [sortField, setSortField] = useState(null);
    const [sortDirection, setSortDirection] = useState('asc');

    useEffect(() => {
        fetchData('achievementUser');
    }, []);

    useEffect(() => {
        const handleDataChanged = () => {
            fetchData('achievementUser');
        };

        EventBus.on('dataChanged', handleDataChanged);

        return () => {
            EventBus.off('dataChanged', handleDataChanged);
        };
    }, []);

    const handleClose = () => {
        setDeleteShow(false);
    };

    const handleDeleteShow = (id) => {
        setDeleteShow(true);
        setDeleteId(id);
    };

    const handleDelete = async () => {
        const message = await deleteData(deleteId);
        handleClose();
        fetchData('achievementUser');
    };

    const handleSort = (field) => {
        const newSortDirection = (sortField === field && sortDirection === 'asc') ? 'desc' : 'asc';
        setSortField(field);
        setSortDirection(newSortDirection);
    };

    // Перевірка на наявність даних перед ітерацією
    if (!data) {
        return null; // або відповідне оброблення відсутності даних
    }

    // Сортування даних
    let sortedData = [...data];
    if (sortField) {
        sortedData = sortedData.sort((a, b) => {
            if (sortDirection === 'asc') {
                return a[sortField] < b[sortField] ? -1 : 1;
            } else {
                return a[sortField] > b[sortField] ? -1 : 1;
            }
        });
    }

    return (
        <div className="mx-5 my-1">
            <TableComponent
                data={sortedData}
                fields={displayFields.achievementUser}
                handleShow1={() => {}}
                handleShow2={handleDeleteShow}
                disableEdit={true}
                handleSort={handleSort} // Передача функції сортування до компонента таблиці
            />
            <DeleteModal id={deleteId} show={deleteShow} handleClose={handleClose} url={'achievementUser'} />
        </div>
    );
};
