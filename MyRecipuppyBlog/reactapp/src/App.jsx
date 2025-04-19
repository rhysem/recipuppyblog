import React, { Component } from 'react';
import AddRecipe from './Components/AddRecipe.jsx';
import './App.css';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { recipes: [], loading: true };
    }

    componentDidMount() {
        //this.populateRecipeData();
    }

    //function saveRecipe() {
    //    var recipeName = document.getElementById("name").val();
    //    var ingredients = document.getElementById("ingredients").val();
    //    var recipeSteps = document.getElementById("steps").val();
    //    console.log(recipeName + " " + ingredients + " " + recipeSteps)
    //    var recipe = { name: recipeName, ingredients, recipeSteps };

    //    const config = {
    //        method: 'POST',
    //        headers: {
    //            'Accept': 'application/json',
    //            'Content-Type': 'application/json'
    //        },
    //        body: JSON.stringify(recipe)
    //    }

    //    //const response = await fetch('api/recipes', config);
    //    const response = await fetch('api/recipes', config);
    //    //return response;
    //}

    static renderRecipesIndex(recipes) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Ingredients</th>
                        <th>Recipe Steps</th>
                    </tr>
                </thead>
                <tbody>
                    {recipes.map(recipe =>
                        <tr key={recipe.id}>
                            <td>{recipe.name}</td>
                            <td>{recipe.ingredients.join(", ")}</td>
                            <td>{recipe.singleStepRecipeText}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    //static renderNewRecipeForm() {
    //    let submitRecipe = async function () {
    //        //saveRecipe();
    //        // idfk. idfk

    //        var recipeName = document.getElementById("name").value;
    //        var ingredients = document.getElementById("ingredients").value;
    //        var recipeSteps = document.getElementById("steps").value;
    //        console.log(recipeName + " " + ingredients + " " + recipeSteps)
    //        var recipe = { name: recipeName, ingredients, recipeSteps };

    //        const config = {
    //            method: 'POST',
    //            headers: {
    //                'Accept': 'application/json',
    //                'Content-Type': 'application/json'
    //            },
    //            body: JSON.stringify(recipe)
    //        }

    //        //const response = await fetch('api/recipes', config);
    //        const response = await fetch('api/recipes', config);
    //        return response;
    //    }

    //    return (
    //        <div id="new-recipe">
    //            <label for="name">Name:</label>
    //            <input type="text" id="name" />
    //            <label for="ingredients">Ingredients:</label>
    //            <input type="text" id="ingredients" />
    //            <label for="steps">Steps:</label>
    //            <input type="text" id="steps" />
    //            <button onClick={submitRecipe}>Submit!</button>
    //        </div>
    //    );
    //}

    render() {
        //let contents = this.state.loading
        //    ? <p><em>Loading... Please be patient!</em></p>
        //    : App.renderRecipesIndex(this.state.recipes);

        //return (
        //    <div>
        //        <h1 id="tabelLabel" >Recipes</h1>
        //        <p>This component demonstrates fetching data from the server.</p>
        //        {contents}
        //    </div>
        //);

        // let contents = App.renderNewRecipeForm();

        return (
            <AddRecipe />
        );
        //return (
        //    <div>
        //        <h1 id="tabelLabel" >New Recipe</h1>
        //        {contents}
        //    </div>
        //);
    }

    //async function populateRecipeData() {
    //    const response = await fetch('api/recipes');
    //    const data = await response.json();
    //    this.setState({ recipes: data, loading: false });
    //}
}
