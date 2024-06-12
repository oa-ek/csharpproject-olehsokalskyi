import {useForm} from 'react-hook-form';
import {userActions} from "../hook/userActions";
import { useEffect, useState } from 'react';

export const ProfilePage = () => {
    const { register, handleSubmit, formState: { errors }, setValue, watch } = useForm();
    const { getCurrentUser,updateCurrentUser } = userActions();
    const [user, setUser] = useState(null);
    const [userId, setUserId] = useState(null);
    const watchedFields = watch(['firstName', 'lastName', 'email', 'userName']);

    useEffect(() => {
        const fetchUser = async () => {
            const userData = await getCurrentUser();
            setUser(userData);
            setValue('firstName', userData.firstName);
            setValue('lastName', userData.lastName);
            setValue('email', userData.email);
            setValue('userName', userData.userName);
            setValue('id', userData.id);
            setUserId(userData.id);
        };

        fetchUser();
    }, []);

    const OnSubmit = async (data) => {
        const result  = await updateCurrentUser(data,userId);
        console.log(result)
    }

    const isDataChanged = user && (
        user.firstName !== watchedFields.firstName ||
        user.lastName !== watchedFields.lastName ||
        user.email !== watchedFields.email ||
        user.userName !== watchedFields.userName
    );

    return(
        <div className="row mt-5 d-flex justify-content-around">
            <div className="col-12 col-md-4 shadow-sm mx-5">
                <div className="form-floating mt-2">
                    <h2>Account info</h2>
                </div>
                <form onSubmit={handleSubmit(OnSubmit)}>
                    <div className="form-floating">
                        <div className="form-floating mb-3">
                            <input type="text" className="form-control" id="floatingInput" disabled
                                   placeholder="" required {...register('id')} />
                            <label htmlFor="floatingInput">Id</label>
                        </div>
                        <div className="row form-floating mb-3">
                            <div className="form-floating col-6">
                                <input type="text" className="form-control" id="InputFirstName" placeholder="" required
                                       {...register('firstName')} />
                                <label htmlFor="InputFirstName">First name</label>
                            </div>
                            <div className="form-floating col-6">
                                <input type="text" className="form-control" id="InputLastName" placeholder="" required
                                       {...register('lastName')} />
                                <label htmlFor="InputLastName">Last name</label>
                            </div>
                        </div>
                        <div className="form-floating mb-3">
                            <input type="email" className="form-control" id="floatingInput"
                                   placeholder="name@example.com" required {...register('email')} />
                            <label htmlFor="floatingInput">Email address</label>
                        </div>
                        <div className="form-floating mb-3">
                            <input type="text" className="form-control" id="floatingInput"
                                   placeholder="user123" required {...register('userName')} />
                            <label htmlFor="floatingInput">Username</label>
                        </div>
                        <div className="form-floating mb-3">
                            <div className="row form-floating mb-3 d-flex justify-content-around">
                                <div className="form-floating d-flex justify-content-between mb-3">
                                    <button className="btn btn-danger" type="button" id="button-delete"
                                            disabled={isDataChanged}>Delete account
                                    </button>

                                    <button className="btn btn-primary" type="submit" id="button-change"
                                            disabled={!isDataChanged}>Change data
                                    </button>
                                </div>

                            </div>
                        </div>
                    </div>
                </form>

            </div>

        </div>
    )
}