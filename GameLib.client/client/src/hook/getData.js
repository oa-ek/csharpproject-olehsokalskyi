import { useState } from 'react';
import api from '../hook/untils/axiousAuthConfig';
import EventBus from './eventBus';

const useApi = (url) => {
    const [data, setData] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);

    const fetchData = async () => {
        setLoading(true);
        try {
            const response = await api.get(url);
            setData(response.data);
            setError(null);
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    const createData = async (newData) => {
        setLoading(true);
        try {
            const response = await api.post(url, newData);
            setError(null);
            EventBus.emit('dataChanged'); // Відправляємо подію
            return response.data.message;
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    const updateData = async (id, updatedData) => {
        setLoading(true);
        try {
            const response = await api.put(`${url}/${id}`, updatedData);
            setError(null);
            EventBus.emit('dataChanged'); // Відправляємо подію
            return response.data.message;
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    const deleteData = async (id) => {
        setLoading(true);
        try {
            const response = await api.delete(`${url}/${id}`);
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