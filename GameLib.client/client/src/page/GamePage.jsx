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
import api from "../hook/untils/axiousAuthConfig";
import {userActions} from "../hook/userActions";
import {Link} from "react-router-dom";
export const GamePage = () =>{
    const [show, setShow] = useState(false);
    const [deleteShow, setDeleteShow] = useState(false);
    const [deleteId, setDeleteId] = useState(null);
    const [editData, setEditData] = useState(null);
    const [alertMessage, setAlertMessage] = useState(null);
    const { data, fetchData } = useApi('');
    const { authorized } = userActions();


    useEffect(() => {
        fetchData('game');

    }, []);
    useEffect(() => {
        fetchData('game');

        const handleDataChanged = () => {
            fetchData('game');
        };

        EventBus.on('dataChanged', handleDataChanged);

        return () => {
            EventBus.off('dataChanged', handleDataChanged);
        };
    }, []);
    const handleClose = () => {
        setShow(false);
        setDeleteShow(false);
        setEditData(null);
        setAlertMessage(null);
    };
    const getGameFromAPI = async () =>{
        const response = await api.get('https://localhost:7226/api/game/getgamefromapi');

    }
    const handleShow = (data) => {
        setShow(true);
        setEditData(data);
    };
    const handleDeleteShow = (id) => {
        setDeleteShow(true);
        setDeleteId(id);
    };

    return (
        <>
            <ShowModalButton handleShow={() => handleShow(null)} type={'post'}/>

                <Button variant="primary" onClick={getGameFromAPI}>GetDataFromAPI</Button>

            <div className="mt-3 d-flex flex-wrap px-2">
                {data && data.map((item) => (
                    <div className="col-xl-3 col-lg-6 col-sm-6 grid-margin stretch-card mb-2" key={item.id}>
                        <div className="card" style={{width: '18rem'}}>
                            <img
                                src={`${item.image.startsWith('https') ? '' : process.env.REACT_APP_SERVER_URL_PHOTO}${item.image}`}
                                className="card-img-top h-6 w-6" alt="Product photo"/>

                            <div className="card-body">
                                <h5 className="card-title">{item.title}</h5>
                                <h6 className="card-text">{item.price}</h6>
                                <div className="d-flex mt-">
                                    <Link className="btn btn-secondary mr-2" to={`/game/${item.id}`}>Details</Link>
                                </div>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
            <FormComponent url={editData ? `game`
                : `game`}
                           type={editData ? 'put' : 'post'}
                           fields={fields.game} show={show}
                           handleClose={handleClose} data={editData}
            />
        </>
    )
}
export const ShowModalButton = ({handleShow, type}) => {
    return (
        <Button variant="primary" onClick={handleShow}>
            {type === 'post' ? 'Add' : 'Edit'}
        </Button>
    );
};