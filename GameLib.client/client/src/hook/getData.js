import { useState } from 'react';
import api from '../hook/untils/axiousAuthConfig';
import EventBus from './eventBus';

const useApi = () => {
    const [data, setData] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);
    const baseURL = process.env.REACT_APP_SERVER_URL

    const fetchData = async (entity) => {
        setLoading(true);
        try {
            const response = await api.get(`${baseURL}/${entity}/list`);
            setData(response.data);
            setError(null);
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };
    const createData = async (entity,newData) => {
        setLoading(true);
        try {
            const response = await api.post(`${baseURL}/${entity}/add`, newData);
            setError(null);
            EventBus.emit('dataChanged'); // Відправляємо подію
            return response.data.message;
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    const updateData = async (entity, id, updatedData) => {
        setLoading(true);
        try {
            const response = await api.put(`${baseURL}/${entity}/update/${id}`, updatedData);
            setError(null);
            EventBus.emit('dataChanged'); // Відправляємо подію
            return response.data.message;
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    const deleteData = async (entity,id) => {
        setLoading(true);
        try {
            const response = await api.delete(`${baseURL}/${entity}/delete/${id}`);
            setError(null);
            EventBus.emit('dataChanged'); // Відправляємо подію
            return response.data.message;
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    return { data, error, loading, fetchData, createData, updateData, deleteData };
};

export default useApi;