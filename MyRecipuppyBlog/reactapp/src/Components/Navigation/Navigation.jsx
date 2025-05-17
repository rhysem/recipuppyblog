import React from 'react';
import './Navigation.css';

function NavButton({setNav, nav}) {
    return (
        <button onClick={() => setNav(nav.link)}>{nav.title}</button>
    );
}

function Navigation({setNav, navLinks}) {
    var navLinkContent = [];

    navLinks.forEach(nav => {
        navLinkContent.push(
            <li className="nav-link">
                <NavButton setNav={setNav} nav={nav} />
            </li>
        );
    });


    return (
        <ul id="nav-bar">
            {navLinkContent}
        </ul>
    );
}

export default Navigation;