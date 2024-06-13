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
import { Modal, Row, Col, Card } from 'react-bootstrap';
import {useNavigate, useParams} from "react-router-dom";
import ReactPlayer from "react-player";
import {useForm} from "react-hook-form";
import Form from 'react-bootstrap/Form';

export const GameDetail = () => {
    const { id } = useParams();
    const [show, setShow] = useState(false);
    const [deleteShow, setDeleteShow] = useState(false);
    const [deleteId, setDeleteId] = useState(null);
    const [editData, setEditData] = useState(null);
    const [alertMessage, setAlertMessage] = useState(null);
    const { data, fetchData,getById,deleteData } = useApi();
    const { authorized } = userActions();
    const [gameData,setgameData] = useState()
    const navigation = useNavigate();
    const [showAchievements, setShowAchievements] = useState(false);

    useEffect(() => {
        const fetchGameDetails = async () => {
            const gameDetails = await getById('game', id);
            setgameData(gameDetails);
        };

        fetchGameDetails();
    }, [id,gameData]);

    const handleClose = () => {
        setShow(false);
        setDeleteShow(false);
        setEditData(null);
        setAlertMessage(null);
    };

    const handleShow = () => {
        setShow(true);
        setEditData(gameData);
    };

    const handleDeleteShow = () => {
        setDeleteShow(true);
        setDeleteId(gameData.id);
    };

    const handleShowAchievements = () => { // Функція для відкриття модального вікна досягнень
        setShowAchievements(true);
    };

    const handleCloseAchievements = () => { // Функція для закриття модального вікна досягнень
        setShowAchievements(false);
    };
    const navigate = useNavigate();

    useEffect(() => {
        const handleDataChanged = async (eventType) => {
            if (eventType === 'delete') {
                navigate('/game');
            } else if (eventType === 'update') {
                const gameDetails = await getById('game', id);
                setgameData(gameDetails);
            }
        };

        EventBus.on('dataChanged', handleDataChanged);

        return () => {
            EventBus.off('dataChanged', handleDataChanged);
        };
    }, []);


    return(
        <>
            {gameData && (
                <div className="row shadow mx-5">

                        <div className='col-md-7'>
                            <ReactPlayer url={gameData.trailer} controls={true} width='90%' height='400px'/>
                        </div>
                        <div className='col-md-5'>
                            <h2>{gameData.title}</h2>
                            <p>{gameData.description}</p>
                            <h6>Release date {new Date(gameData.releaseDate).toISOString().split('T')[0]}</h6>
                            <h5> By {gameData.publisher.title}</h5>
                            <h5>Price: {gameData.price}</h5>
                            <Button variant="danger" onClick={handleDeleteShow}>Delete</Button>

                        </div>
                    <div className="row mt-3">
                        <div className="col-md-3">
                            <h5>Developers: </h5>
                            {gameData.developers.map((developer, index, arr) => (
                                <span key={developer.id}>{developer.title}{index !== arr.length - 1 ? ', ' : ''}</span>
                            ))}
                        </div>
                        <div className="col-md-3">
                            <h5>Platforms:</h5>
                            {gameData.platforms.map((platform, index, arr) => (
                                <span key={platform.id}>{platform.title}{index !== arr.length - 1 ? ', ' : ''}</span>
                            ))}
                        </div>
                        <div className="col-md-3">
                            <h5>Genres:</h5>
                            {gameData.genres.map((genre, index, arr) => (
                                <span key={genre.id}>{genre.title}{index !== arr.length - 1 ? ', ' : ''}</span>
                            ))}
                        </div>
                        <div className="col-md-3">
                            <h5>Languages</h5>
                            {gameData.languages.map((language, index, arr) => (
                                <span key={language.id}>{language.title}{index !== arr.length - 1 ? ', ' : ''}</span>
                            ))}
                        </div>
                    </div>
                </div>
            )}
            <ShowModalButton handleShow={handleShow} type={'put'}/>
            <FormComponent url={`game`}
                           type={'put'}
                           fields={fields.game} show={show}
                           handleClose={handleClose} data={editData}
            />
            <DeleteModal id={deleteId} show={deleteShow} handleClose={handleClose}
                         url={"game"}/>


            <Button variant="primary" onClick={handleShowAchievements}>
                Show Achievements
            </Button>
            <AchievementModelWindow achievements={gameData?.achievements} show={showAchievements} handleClose={handleCloseAchievements}  />
            <DeleteModal url='game' id={deleteId} show={deleteShow} handleClose={handleClose}/>
        </>
    )
}
const ShowModalButton = ({handleShow, type}) => {
    return (
        <Button variant="primary" onClick={handleShow}>
            {type === 'put' ? 'Edit' : 'Add'}
        </Button>
    );
};


const AchievementModelWindow = ({ achievements, show, handleClose}) => {
    if (!achievements) {
        return null;
    }
    return (
        <Modal show={show} onHide={handleClose} >
            <Modal.Header closeButton>
                <Modal.Title>Achievements</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Row>
                    {achievements.map((achievement, index) => (
                        <Col md={12} key={achievement.id} className="mb-4">
                            <Card style={{ width: '18rem' }}>
                                <Card.Body>
                                    <Card.Text>{achievement.title}</Card.Text>
                                    <Card.Text>{achievement.description}</Card.Text>
                                    <Card.Text>
                                        Players get: {achievement.playersGet}%
                                    </Card.Text>
                                </Card.Body>
                            </Card>
                        </Col>
                    ))}
                </Row>
            </Modal.Body>
        </Modal>
    );
};