import React, { useState, useEffect } from 'react';
import './GetRecipes.css';

function GetRecipes() {
    const getAllRecipes = async function () {
        const url = "api/recipes";
        const resp = await fetch(url);
        const body = await resp.json();

        setRecipes(body);
    };

    const [recipes, setRecipes] = useState([]);

    useEffect(() => {
        getAllRecipes();
    }, []);

    // TO DO: swap out Repository logic and use dummy data to test - don't run up AWS reads for re-rendering CSS etc
    var recipesContent = [];
    recipes.forEach(recipe => {
        recipesContent.push(
            <div className="recipe">
                <div className="name">Name: {recipe.name}</div>
                <div className="description">Description: {recipe.description}</div>
                <div className="ingredients">Ingredients: {recipe.ingredients}</div>
                <div className="directions">Directions: {recipe.directions}</div>
            </div>
        );
    });
        // TO DO: if check in return - make sure recipesContent not empty

    return (
        <div id="recipes-container">
            <h3>Recipe List</h3>
            {recipesContent}
        </div>
    );
}

export default GetRecipes;