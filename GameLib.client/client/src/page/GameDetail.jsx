import React, { useState, useEffect } from 'react';
import useApi from '../hook/getData';
import Button from 'react-bootstrap/Button';
import { displayFields, fields } from '../datadef/datadef';
import { FormComponent } from '../components/FormComponent';
import TableComponent from "../components/TableComponent";
import DeleteModal from "../components/ModalDeleteObject";
import EventBus from "../hook/eventBus";
import { debounce } from 'lodash';
import api from "../hook/untils/axiousAuthConfig";
import { userActions } from "../hook/userActions";
import { Modal, Row, Col, Card } from 'react-bootstrap';
import { useNavigate, useParams } from "react-router-dom";
import ReactPlayer from "react-player";
import { useForm } from "react-hook-form";
import Form from 'react-bootstrap/Form';
import StarRatings from 'react-star-ratings';

export const GameDetail = () => {
    const { id } = useParams();
    const [show, setShow] = useState(false);
    const [deleteShow, setDeleteShow] = useState(false);
    const [deleteId, setDeleteId] = useState(null);
    const [editData, setEditData] = useState(null);
    const [alertMessage, setAlertMessage] = useState(null);
    const { data, fetchData, getById, deleteData } = useApi();
    const [gameData, setGameData] = useState();
    const navigation = useNavigate();
    const [showAchievements, setShowAchievements] = useState(false);
    const [showRatingForm, setShowRatingForm] = useState(false);
    const [ratingData, setRatingData] = useState(null);
    const { getCurrentUser } = userActions();
    const [currentUser, setCurrentUser] = useState(null);
    const [selectedRating, setSelectedRating] = useState(null);
    const [showDeleteModal, setShowDeleteModal] = useState(false);
    const [showEditModal, setShowEditModal] = useState(false);
    const navigate = useNavigate()
    useEffect(() => {
        const fetchCurrentUser = async () => {
            const user = await getCurrentUser();
            setCurrentUser(user);
        };

        fetchCurrentUser();
    }, []);

    const handleShowRatingForm = () => {
        const userRating = gameData.ratings.find(rating => rating.user.email === currentUser.email);
        if (userRating) {
            alert('You have already rated this game');
            return;
        }
        setShowRatingForm(true);
        setRatingData(null);
    };

    const handleDeleteRating = (ratingId) => {
        const rating = gameData.ratings.find(rating => rating.id === ratingId);
        if (rating.user.email !== currentUser.email) {
            alert('You can only delete your own ratings');
            return;
        }
        setSelectedRating(rating);
        setShowDeleteModal(true);
    };

    const handleEditRating = (ratingId) => {
        const rating = gameData.ratings.find(rating => rating.id === ratingId);
        if (rating.user.email !== currentUser.email) {
            alert('You can only edit your own ratings');
            return;
        }
        setSelectedRating(rating);
        setShowEditModal(true);
    };
    const fetchGameDetails = async () => {
        console.log(id)
        const gameDetails = await getById('game', id);
        if (gameDetails) {
            setGameData(gameDetails);
        }
    };
    useEffect(() => {


        fetchGameDetails();
    }, [id]);

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

    const handleShowAchievements = () => {
        setShowAchievements(true);
    };

    const handleCloseAchievements = () => {
        setShowAchievements(false);
    };

    const handleCloseRatingForm = () => {
        setShowRatingForm(false);
        setRatingData(null);
    };

    const handleCloseDeleteModal = () => {
        setShowDeleteModal(false);
        setSelectedRating(null);
    };

    const handleCloseEditModal = () => {
        setShowEditModal(false);
        setSelectedRating(null);
    };
    const handleBuGame = async () => {
        await api.post(`${process.env.REACT_APP_SERVER_URL}/game/buygame/${id}`);
        EventBus.emit('dataChanged', 'buy');
        fetchGameDetails();
    };

    useEffect(() => {
        const handleDataChanged = async (eventType) => {
            if (eventType === 'delete') {
                navigate('/game');
            } else if (['update', 'create', 'achievement', 'buy'].includes(eventType)) {
                fetchGameDetails();
            }
        };

        EventBus.on('dataChanged', handleDataChanged);

        return () => {
            EventBus.off('dataChanged', handleDataChanged);
        };
    }, []);

    const gameExists = (gameID) => {
        return currentUser.games.some(game => game.id === gameID);
    }

    return (
        <>
            {gameData && (
                <div className="row shadow mx-5">
                    <div className='col-md-7'>
                        <ReactPlayer url={gameData.trailer} controls={true} width='90%' height='400px' />
                    </div>
                    <div className='col-md-5'>
                        <h2>{gameData.title}</h2>
                        <p>{gameData.description}</p>
                        <h6>Release date {new Date(gameData.releaseDate).toISOString().split('T')[0]}</h6>
                        <h5> By {gameData.publisher.title}</h5>
                        <h5>Price: {gameData.price}</h5>
                        <div className='d-flex gap-2'>
                            <Button variant="danger" onClick={handleDeleteShow} className="me-3">Delete</Button>
                            <ShowModalButton handleShow={handleShow} type={'put'} className="me-3"/>
                            <Button variant="primary" onClick={handleShowAchievements}>
                                Show Achievements
                            </Button>
                            {!gameExists(gameData.id) && (
                                <Button variant="primary" onClick={handleBuGame}>Buy</Button>
                            )}
                        </div>


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
                    <div className="col-md-6">
                        <h4>Ratings</h4>
                        <Button variant="primary" onClick={handleShowRatingForm}>Add Rating</Button>
                        {gameData.ratings && (
                            gameData.ratings.length === 0 ? (
                                <p>No ratings yet</p>
                            ) : (
                                gameData.ratings.map((rating) => (
                                    rating && rating.user && rating.ratingValue ? (
                                        <div key={rating.id}>
                                            <p>{rating.user.userName}</p>
                                            <StarRatings
                                                rating={parseFloat(rating.ratingValue)}
                                                starRatedColor="gold"
                                                numberOfStars={5}
                                                name='rating'
                                                starDimension="20px"
                                                starSpacing="2px"
                                            />
                                            <p>{rating.comment}</p>
                                            {currentUser && currentUser.email === rating.user.email && (
                                                <>
                                                    <Button variant="primary" onClick={() => handleEditRating(rating.id)}>Edit</Button>
                                                    <Button variant="danger" onClick={() => handleDeleteRating(rating.id)}>Delete</Button>
                                                </>
                                            )}
                                        </div>
                                    ) : null
                                ))
                            )
                        )}
                    </div>
                </div>
            )}

            <FormComponent
                url={`game`}
                type={'put'}
                fields={fields.game}
                show={show}
                handleClose={handleClose}
                data={editData}
            />
            <DeleteModal
                id={deleteId}
                show={deleteShow}
                handleClose={handleClose}
                url={"game"}
            />

            <AchievementModelWindow
                achievements={gameData?.achievements}
                show={showAchievements}
                handleClose={handleCloseAchievements}
                gameId={id}
            />
            <DeleteModal
                url='rating'
                id={selectedRating?.id}
                show={showDeleteModal}
                handleClose={handleCloseDeleteModal}
            />
            <RatingFormComponent
                url={`rating`}
                type={selectedRating ? 'put' : 'post'}
                show={showRatingForm || showEditModal}
                handleClose={selectedRating ? handleCloseEditModal : handleCloseRatingForm}
                data={selectedRating || ratingData}
                gameId={id}
            />
        </>
    )
}

const ShowModalButton = ({ handleShow, type }) => {
    return (
        <Button variant="primary" onClick={handleShow}>
            {type === 'put' ? 'Edit' : 'Add'}
        </Button>
    );
};

const AchievementModelWindow = ({ achievements, show, handleClose,gameId }) => {
    const { createData, updateData } = useApi();
    const [achievementsUser, setachievementsUser] = useState([])
    useEffect(() => {
        const fetchAchievements = async () => {
            const response = await api.get(`${process.env.REACT_APP_SERVER_URL}/achievementuser/getbygameanduser/${gameId}`);
            setachievementsUser(response.data);
        };

        fetchAchievements();
    },[])
    if (!achievements) {
        return null;
    }

    const getAchievement = async (achID) => {
        const resBody = {
            achievementId: achID,
            data: new Date().toISOString()
        };
        await createData('achievementUser', resBody);
        EventBus.emit('dataChanged', 'achievement');
    };
    const achievementExists = (achID) => {
        return achievementsUser.some(achievementUser => achievementUser.achievement.id === achID);
    }

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Achievements</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Row>
                    {achievements.map((achievement) => (
                        <Col md={12} key={achievement.id} className="mb-4">
                            <Card style={{ width: '18rem' }}>
                                <Card.Body>
                                    <Card.Text>{achievement.title}</Card.Text>
                                    <Card.Text>{achievement.description}</Card.Text>
                                    <Card.Text>
                                        Players get: {achievement.playersGet}%
                                    </Card.Text>
                                    {!achievementExists(achievement.id) && (
                                        <Button variant={'primary'} onClick={()=> getAchievement(achievement.id)}>Get</Button>
                                    )}
                                </Card.Body>
                            </Card>
                        </Col>
                    ))}
                </Row>
            </Modal.Body>
        </Modal>
    );
};

export const RatingFormComponent = ({ url, type, show, handleClose, data, gameId }) => {
    const { register, handleSubmit, setValue, formState: { errors } } = useForm();
    const [rating, setRating] = useState(data ? data.ratingValue : 0);
    const { createData, updateData } = useApi();

    useEffect(() => {
        if (data) {
            setValue('ratingValue', data.ratingValue);
            setValue('comment', data.comment);
        }
    }, [data]);

    const onSubmit = (formData) => {
        formData.ratingValue = rating;
        formData.date = new Date().toISOString();
        formData.gameId = gameId;
        if(type === 'put'){
            formData.id = data.id
        }
        type === 'post' ? createData(url, formData) : updateData(url, data.id, formData);
        handleClose();
        EventBus.emit('dataChanged');
    };

    const changeRating = (newRating) => {
        setRating(newRating);
    };

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>{type === 'post' ? 'Create Rating' : 'Edit Rating'}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form onSubmit={handleSubmit(onSubmit)}>
                    <Form.Group className="mb-3">
                        <Form.Label>Rating</Form.Label>
                        <StarRatings
                            rating={rating}
                            changeRating={changeRating}
                            numberOfStars={5}
                            name='rating'
                        />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Comment</Form.Label>
                        <Form.Control type="text" {...register('comment', { required: true })} />
                        {errors.comment && <p>This field is required</p>}
                    </Form.Group>
                    <Button variant="primary" type="submit">Submit</Button>
                </Form>
            </Modal.Body>
        </Modal>
    );
};
