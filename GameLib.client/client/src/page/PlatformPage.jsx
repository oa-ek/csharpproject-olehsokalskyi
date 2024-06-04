// В файлі GenrePage.jsx
import React, {useState, useEffect } from 'react';
import useApi from '../hook/getData';
import Button from 'react-bootstrap/Button';
import Alert from 'react-bootstrap/Alert';
import { displayFields, fields } from '../datadef/datadef';
import { FormComponent } from '../components/FormComponent';
import TableComponent from "../components/TableComponent";
import DeleteModal from "../components/ModalDeleteObject";
import EventBus from "../hook/eventBus";
import { debounce } from 'lodash';

const GenrePage = () => {
    const { data, fetchData, message, deleteData } = useApi('https://localhost:7226/api/platform/list');
    useEffect(() => {
        fetchData();
    }, []);

    const [show, setShow] = useState(false);
    const [deleteShow, setDeleteShow] = useState(false);
    const [deleteId, setDeleteId] = useState(null);
    const [editData, setEditData] = useState(null);
    const [alertMessage, setAlertMessage] = useState(null);

    const handleClose = () => {
        setShow(false);
        setDeleteShow(false);
        setEditData(null);
        setAlertMessage(null);
    };
    const handleShow = (data) => {
        setShow(true);
        setEditData(data);
    };
    const handleDeleteShow = (id) => {
        setDeleteShow(true);
        setDeleteId(id);
    };

    const handleDelete = async () => {
        const message = await deleteData(deleteId);
        setAlertMessage(message);
        handleClose();
        fetchData();
    };

    const debouncedFetchData = debounce(fetchData, 1000);

    useEffect(() => {
        debouncedFetchData();

        const handleDataChanged = () => {
            debouncedFetchData();
        };

        EventBus.on('dataChanged', handleDataChanged);

        // Не забудьте відписатися від події, коли компонент розмонтується
        return () => {
            EventBus.off('dataChanged', handleDataChanged);
        };
    }, [debouncedFetchData]);

    return(
        <div className="mx-5 my-1">
            {alertMessage && <Alert variant="success">{alertMessage}</Alert>}
            <ShowModalButton handleShow={() => handleShow(null)} type={'post'}/>
            <TableComponent data={data} fields={displayFields.platform} handleShow1={handleShow}
                            handleShow2={handleDeleteShow}/>

            <FormComponent url={editData ? `https://localhost:7226/api/platform/update`
                : `https://localhost:7226/api/platform/add`}
                           type={editData ? 'put' : 'post'}
                           fields={fields.platform} show={show}
                           handleClose={handleClose} data={editData}
            />
            <DeleteModal id={deleteId} show={deleteShow} handleClose={handleClose}
                         url={"https://localhost:7226/api/platform/delete"}/>
        </div>
    )
};

export const ShowModalButton = ({ handleShow, type }) => {
    return (
        <Button variant="primary" onClick={handleShow}>
            {type === 'post' ? 'Add' : 'Edit'}
        </Button>
    );
};
export default GenrePage;