import React, { Component } from 'react';
import AddRecipe from './Components/AddRecipe/AddRecipe.jsx';
import GetRecipes from './Components/GetRecipes/GetRecipes.jsx';
import './App.css';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { loading: true, display: "" };
    }

    //componentDidMount() {
    //    this.populateRecipeData();
    //}

    //static renderRecipesIndex(recipes) {
    //    return (
    //        <table className='table table-striped' aria-labelledby="tabelLabel">
    //            <thead>
    //                <tr>
    //                    <th>Name</th>
    //                    <th>Ingredients</th>
    //                    <th>Recipe Steps</th>
    //                </tr>
    //            </thead>
    //            <tbody>
    //                {recipes.map(recipe =>
    //                    <tr key={recipe.id}>
    //                        <td>{recipe.name}</td>
    //                        <td>{recipe.ingredients.join(", ")}</td>
    //                        <td>{recipe.singleStepRecipeText}</td>
    //                    </tr>
    //                )}
    //            </tbody>
    //        </table>
    //    );
    //}

    setDisplay = function(display) {
        this.setState({ display: display });
    }

    render() {
        //let contents = this.state.loading
        //    ? <p><em>Loading... Please be patient!</em></p>
        //    : App.renderRecipesIndex(this.state.recipes);



        // MAYBE: use react-router-dom/similar?
        return (
            <div>
                {(() => {
                    switch (this.state.display) {
                        case "add":
                            return (<AddRecipe />);
                        case "getAll":
                            return (<GetRecipes />);
                        default:
                            return (
                                <div className="linkNav">
                                    <div>Click to navigate: </div>
                                    <a onClick={() => this.setDisplay("add")}>Add Recipe</a>
                                    <a onClick={() => this.setDisplay("getAll")}>Show All Recipes</a>
                                </div>
                            );
                    }
                })()}
            </div>
        );
    }

    //async function populateRecipeData() {
    //    const response = await fetch('api/recipes');
    //    const data = await response.json();
    //    this.setState({ recipes: data, loading: false });
    //}
}
