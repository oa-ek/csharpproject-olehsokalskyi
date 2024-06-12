import { Link } from 'react-router-dom';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import {userActions} from "../hook/userActions";
import {useState,useEffect} from "react";

import { useContext } from 'react';
import { AuthContext } from './Authorize';

function CollapsibleExample() {
    const { authorized, setAuthorized } = useContext(AuthContext);
    const {logout} = userActions()
    // Rest of your code...

    const OnLogout = ()=>{
        logout();
        setAuthorized(false);
    }
    return (
        <Navbar collapseOnSelect expand="lg" className="bg-body-tertiary">
            <Container>
                <Navbar.Brand href="#home">GameLib</Navbar.Brand>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link as={Link} to="/">Genre</Nav.Link>
                        <Nav.Link as={Link} to="/platform">Platform</Nav.Link>
                        <Nav.Link as={Link} to="/developers">Developers</Nav.Link>
                        <Nav.Link as={Link} to='/achievements'>Achievements</Nav.Link>
                    </Nav>
                    <Nav>
                        {authorized ? (
                            <>
                                <Nav.Link as={Link} to='/profile'>Profile</Nav.Link>
                                <button className='nav-link'onClick={OnLogout}>Logout</button>
                            </>
                        ) : (
                            <Nav.Link as={Link} to='login'>Login</Nav.Link>
                        )}
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default CollapsibleExample;