// AuthContext.js
import React, { createContext, useState, useEffect } from 'react';
import { userActions } from "../hook/userActions";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const { isAuthorize } = userActions();
    const [authorized, setAuthorized] = useState(false);

    useEffect(() => {
        const checkAuthorization = async () => {
            const auth = await isAuthorize();
            setAuthorized(auth);
        };

        checkAuthorization();
    }, []);

    return (
        <AuthContext.Provider value={{ authorized, setAuthorized }}>
            {children}
        </AuthContext.Provider>
    );
};