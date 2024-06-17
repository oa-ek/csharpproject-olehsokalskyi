import React, { useState, useEffect } from 'react';
import useApi from '../hook/getData';
import Button from 'react-bootstrap/Button';
import Alert from 'react-bootstrap/Alert';
import { fields } from '../datadef/datadef';
import { FormComponent } from '../components/FormComponent';
import DeleteModal from '../components/ModalDeleteObject';
import EventBus from '../hook/eventBus';
import { Link } from 'react-router-dom';
import api from '../hook/untils/axiousAuthConfig';
import { userActions } from '../hook/userActions';

export const GamePage = () => {
    const { data, fetchData, message, deleteData } = useApi('https://localhost:7226/api/game/list');
    const { authorized } = userActions();

    const [show, setShow] = useState(false);
    const [deleteShow, setDeleteShow] = useState(false);
    const [deleteId, setDeleteId] = useState(null);
    const [editData, setEditData] = useState(null);
    const [alertMessage, setAlertMessage] = useState(null);
    const [searchQuery, setSearchQuery] = useState('');
    const [sortField, setSortField] = useState(null);
    const [sortDirection, setSortDirection] = useState('asc');
    const {isAdmin} = userActions()

    useEffect(() => {
        fetchData('game');
    }, []);

    useEffect(() => {
        const handleDataChanged = () => {
            fetchData('game');
        };

        EventBus.on('dataChanged', handleDataChanged);

        return () => {
            EventBus.off('dataChanged', handleDataChanged);
        };
    }, []);

    useEffect(() => {
        if (message) {
            setAlertMessage(message);
        }
    }, [message]);

    const handleClose = () => {
        setShow(false);
        setDeleteShow(false);
        setEditData(null);
        setAlertMessage(null);
    };

    const getGameFromAPI = async () => {
        try {
            const response = await api.get('https://localhost:7226/api/game/getgamefromapi');
            fetchData('game');
        } catch (error) {
            console.error('Error fetching data from API:', error);
        }
    };

    const handleShow = (data) => {
        setShow(true);
        setEditData(data);
    };

    const handleDeleteShow = (id) => {
        setDeleteShow(true);
        setDeleteId(id);
    };

    const handleSearch = (event) => {
        setSearchQuery(event.target.value);
    };

    const handleSort = (field) => {
        const newSortDirection = (sortField === field && sortDirection === 'asc') ? 'desc' : 'asc';
        setSortField(field);
        setSortDirection(newSortDirection);
    };

    // Додайте перевірку на наявність даних перед їхнім використанням
    if (!data) {
        return null;
    }

    // Сортування даних за полем sortField і напрямом sortDirection
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

    const filteredData = sortedData.filter((item) =>
        item.title.toLowerCase().includes(searchQuery.toLowerCase())
    );

    return (
        <div className='mx-5'>
            <div>

                        <ShowModalButton handleShow={() => handleShow(null)} type={'post'} />

                        <Button variant="primary" onClick={getGameFromAPI}>Get Data From API</Button>




                <input  type="text" value={searchQuery} onChange={handleSearch} placeholder="Search..." />
            </div>


            <div className="mt-3 d-flex flex-wrap px-2">
                {filteredData.map((item) => (
                    <div className="col-xl-3 col-lg-6 col-sm-6 grid-margin stretch-card mb-2" key={item.id}>
                        <div className="card" style={{ width: '18rem' }}>
                            <img
                                src={`${item.image.startsWith('https') ? '' : process.env.REACT_APP_SERVER_URL_PHOTO}${item.image}`}
                                className="card-img-top h-6 w-6"
                                alt="Product photo"
                            />

                            <div className="card-body">
                                <h5 className="card-title">{item.title}</h5>
                                <h6 className="card-text">{item.price}</h6>
                                <p className="card-text">Release Date: {item.releaseDate}</p>
                                <div className="d-flex mt-">
                                    <Link className="btn btn-secondary mr-2" to={`/game/${item.id}`}>Details</Link>
                                </div>
                            </div>
                        </div>
                    </div>
                ))}
            </div>

            {alertMessage && <Alert variant="success">{alertMessage}</Alert>}

            <FormComponent
                url={editData ? `game` : `game`}
                type={editData ? 'put' : 'post'}
                fields={fields.game}
                show={show}
                handleClose={handleClose}
                data={editData}
            />

            <DeleteModal id={deleteId} show={deleteShow} handleClose={handleClose} url={"game"} />
        </div>
    );
};

export const ShowModalButton = ({ handleShow, type }) => {
    return (
        <Button variant="primary" onClick={handleShow}>
            {type === 'post' ? 'Add' : 'Edit'}
        </Button>
    );
};

export default GamePage;
