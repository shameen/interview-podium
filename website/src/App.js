import React from 'react';
import logo from './Podium-logo@2x.png';
import './App.css';
import MainContent from './components/MainContent';

function App() {
    return (
        <div className="App">
            <header className="header">
                <img src={logo} className="header-logo" alt="logo" />
                <span className="header-logo-suffix">SA Case Study</span>
            </header>
            <MainContent></MainContent>
        </div>
    );
}

export default App;
