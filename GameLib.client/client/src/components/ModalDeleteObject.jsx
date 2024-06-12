
import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import useApi from "../hook/getData";

const DeleteModal = ({ id, show, handleClose, url  }) => {
    const { deleteData } = useApi();
    const onHandleDelete = async () => {
        const message = await deleteData(url,id);
        handleClose();
    }
    return (
        <>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Delete object ?</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    Object <b>{id}</b>  will be deleted. Are you sure ?
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Cancel
                    </Button>
                    <Button variant="danger" onClick={() => {
                       onHandleDelete()
                    }}>
                        Confirm
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
};

export default DeleteModal;