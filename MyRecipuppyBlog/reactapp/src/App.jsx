import React, { Component } from 'react';
import AddRecipe from './Components/AddRecipe/AddRecipe.jsx';
import GetRecipes from './Components/GetRecipes/GetRecipes.jsx';
import Navigation from './Components/Navigation/Navigation.jsx';
import Home from './Components/Home/Home.jsx';
import './App.css';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { loading: true, display: "" };
    }

    setDisplay = (display) => {
        this.setState({ display: display });
    }

    render() {
        var navLinks = [{ link: "add", title: "Add Recipe" }, { link: "getAll", title: "Get All Recipes" }];

        return (
            <div>
                <Navigation setNav={this.setDisplay} navLinks={navLinks} />
                {(() => {
                    switch (this.state.display) {
                        case "add":
                            return (<AddRecipe />);
                        case "getAll":
                            return (<GetRecipes />);
                        default:
                            return (<Home />);
                    }
                })()}
            </div>
        );
    }
}
