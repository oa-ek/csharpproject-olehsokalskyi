import useApi from "../hook/getData";
import React, { useEffect, useState } from "react";
import EventBus from "../hook/eventBus";
import TableComponent from "../components/TableComponent";
import { displayFields } from "../datadef/datadef";
import DeleteModal from "../components/ModalDeleteObject";
import axios from 'axios';
import { useForm } from 'react-hook-form';
import api from "../hook/untils/axiousAuthConfig";

export const UserPage = () => {
    const { data, fetchData, message, deleteData } = useApi();
    const [deleteShow, setDeleteShow] = useState(false);
    const [deleteId, setDeleteId] = useState(null);
    const [show, setShow] = useState(false);
    const [selectedUserId, setSelectedUserId] = useState(null);
    const [roles, setRoles] = useState([]);

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
        fetchData('user');
    };
    const fetchRoles = async () => {
        try {
            const response = await axios.get(`${process.env.REACT_APP_SERVER_URL}/user/role/list`);
            setRoles(response.data);
        } catch (error) {
            console.error('Error fetching roles:', error);
        }
    };
    useEffect(() => {
        fetchData('user');
        fetchRoles();
    }, []);
    useEffect(() => {
        fetchData('user');
        const handleDataChanged = () => {
            fetchData('user');
        };
        EventBus.on('dataChanged', handleDataChanged);
        return () => {
            EventBus.off('dataChanged', handleDataChanged);
        };
    }, []);
    const handleShow = (userId) => {
        setSelectedUserId(userId);
        setShow(true);
    };
    const handleCloseForm = () => {
        setShow(false);
        setSelectedUserId(null);
    };
    return (
        <div className="mx-5 my-1">
            <TableComponent data={data} fields={displayFields.user} handleShow1={handleShow}
                            handleShow2={handleDeleteShow}  />
            <DeleteModal id={deleteId} show={deleteShow} handleClose={handleClose}
                         url={"user"} />
            {show && <UserChangeRoleForm userId={selectedUserId} roles={roles} handleClose={handleCloseForm} />}
        </div>
    )
}

const UserChangeRoleForm = ({ userId, roles, handleClose }) => {
    const { register, handleSubmit,setValue, formState: { errors } } = useForm();
    const onSubmit = async (data) => {
        try {
            console.log(data);
            data.userId = userId.id;

            const response = await api.post(`${process.env.REACT_APP_SERVER_URL}/user/changerole`,  data );
            handleClose();
            EventBus.emit('dataChanged');

        } catch (error) {
            console.error('Error changing role:', error);
        }
    };
    useEffect(() => {
        setValue('roleId', userId.role.id);
    }, [userId]);
    return (
        <div className="modal show d-block" tabIndex="-1" role="dialog">
            <div className="modal-dialog" role="document">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title">Change User Role</h5>
                    </div>
                    <form onSubmit={handleSubmit(onSubmit)}>
                        <div className="modal-body">
                            <div className="form-group">
                                <label htmlFor="roleId">Role</label>
                                <select id="roleId" className="form-control" {...register('roleId', { required: true })}>
                                    {roles.map(role => (
                                        <option key={role.id} value={role.id}>{role.name}</option>
                                    ))}
                                </select>
                                {errors.roleId && <span className="text-danger">This field is required</span>}
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" onClick={handleClose}>Close</button>
                            <button type="submit" className="btn btn-primary">Save changes</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
};
