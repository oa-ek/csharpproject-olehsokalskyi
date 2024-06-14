import axios from "axios";
import api from './untils/axiousAuthConfig'
export const userActions = () => {
    const login = async (data) => {

        const response = await api.post('https://localhost:7226/api/user/login', data);

        const user = response.data;
        if (user.token) {
            localStorage.setItem('token',user.token);
            return true
        }
        else {
            return false
        }
    }
    const logout = () => {
        if (localStorage.getItem('token')) {
            localStorage.removeItem('token');
        }
    }
    const register = async (user) => {
        const massage = await axios.post('https://localhost:7226/api/user/register', user);
        return massage;
    }
    const editUser = async (user) => {
        const massage = await axios.put('https://localhost:7226/api/user/edit', user);
        return massage;
    }
    const deleteUser = async (id) => {
        const massage = await axios.delete(`https://localhost:7226/api/user/delete/${id}`);
        return massage;
    }
    const isAuthorize = async ()=>{
        const token = localStorage.getItem('token');

        if(token){
            return true;
        }
        return false;
    }
    const getCurrentUser = async () => {
        const response = await api.get('https://localhost:7226/api/user/getcurrent');
        return response.data;
    }
    const updateCurrentUser = async (data,id) => {
        console.log(id)
        const response =  await api.put(`https://localhost:7226/api/user/update/${id}`,data)
        return response.data
    }
    const changePassword = async (data) => {
        try {
            const response = await axios.post(`${process.env.REACT_APP_SERVER_URL}/user/changepassword`, data);
            return response.data;
        } catch (error) {
            console.error('Error changing password:', error);
            return null;
        }
    };


    return { login, logout, register, isAuthorize, editUser, deleteUser, getCurrentUser,updateCurrentUser,changePassword };
}
