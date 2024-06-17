import Button from "react-bootstrap/Button";
import { useForm } from 'react-hook-form';
import { userActions } from "../hook/userActions";
import { useEffect, useState } from 'react';

export const RegisterPage = () => {
    const { register, handleSubmit, formState: { errors }, setValue, watch } = useForm();
    return(
        <div className="row mt-5 d-flex justify-content-around">
            <div className="col-12 col-md-4 shadow-sm mx-5">
                <div className="form-floating mt-2">
                    <h2>Regedit</h2>
                </div>
                <form >
                    <div className="form-floating">

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
                                <div className="form-floating d-flex justify-content-center mb-3">
                                    <Button variant={"primary"}   type='submit'     >Regedit</Button>
                                </div>

                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
            )
}