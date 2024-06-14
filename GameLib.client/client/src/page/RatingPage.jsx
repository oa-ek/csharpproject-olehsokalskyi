import useApi from "../hook/getData";
import React, {useEffect, useState} from "react";
import EventBus from "../hook/eventBus";
import { displayFields, fields } from '../datadef/datadef';
import TableComponent from "../components/TableComponent";
import DeleteModal from "../components/ModalDeleteObject";

export const RatingPage = () => {
    const { data, fetchData, message, deleteData } = useApi();
            const [deleteShow, setDeleteShow] = useState(false);
            const [deleteId, setDeleteId] = useState(null);
            const [show, setShow] = useState(false);

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
                fetchData('rating');

            };
            useEffect(() => {
                fetchData('rating');
            }, []);
            useEffect(() => {
                fetchData('rating');

                const handleDataChanged = () => {
                    fetchData('rating');
                };

                EventBus.on('dataChanged', handleDataChanged);

                return () => {
            EventBus.off('dataChanged', handleDataChanged);
        };
    }, []);
    const handleShow = (data) => {
        setShow(true);
    };

    return(
        <div className="mx-5 my-1">
            <TableComponent data={data} fields={displayFields.rating} handleShow1={handleShow}
                            handleShow2={handleDeleteShow} disableEdit/>
            <DeleteModal id={deleteId} show={deleteShow} handleClose={handleClose}
                         url={"rating"}/>
        </div>
    )
}