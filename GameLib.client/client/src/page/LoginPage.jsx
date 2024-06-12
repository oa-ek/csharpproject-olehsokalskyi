
import {useForm} from 'react-hook-form';
import {userActions} from "../hook/userActions";
import {Link, useNavigate} from "react-router-dom";
import {useEffect, useState} from "react";
import { useContext } from 'react';
import { AuthContext } from '../components/Authorize';

export const LoginPage = () => {
    const {isAuthorize,logout} = userActions()
    const {register, handleSubmit, formState: {errors}} = useForm();
    const {login} = userActions();
    const navigation = useNavigate();
    const { setAuthorized } = useContext(AuthContext);
    const onSubmit = data => {
        const result  = login(data);
        if(result){
            setAuthorized(true);
            navigation('/')
        }
    }

    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <div className="row mt-5">
                <div className="col-12 col-md-3 p-3 text-center border border-dark mx-auto">
                    <div className='row'>
                        <div className=' p-3'>
                            <h1>Login</h1>
                            <div className="form-floating mb-3">
                                <input type="email" className="form-control" id="floatingInput"
                                       placeholder="Email" {...register('email')} />
                                <label htmlFor="floatingInput">Email address</label>
                            </div>
                            <div className="form-floating mb-3">
                                <input type="password" className="form-control" id="floatingPassword"
                                       placeholder="Password"
                                       {...register("Password", {})}
                                />
                                <label htmlFor="floatingPassword">Password</label>
                            </div>
                            <div className="mt-2">
                                <button className='btn btn-primary' type='submit'>Login</button>
                            </div>
                            <div className="mt-2">
                                <a className='link-dark' href='/register'>Register</a>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </form>
    );
}

