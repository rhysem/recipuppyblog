import React, { useState, useEffect } from 'react';
import './GetRecipes.css';
import '../RecipeCard/RecipeCard.jsx';
import RecipeCard from '../RecipeCard/RecipeCard.jsx';

function GetRecipes() {

    const [recipes, setRecipes] = useState([]);
    const [testMode, setTestMode] = useState(true);
    const buttonText = `Test mode: ${testMode ? "ON" : "OFF"}`;

    const getAllRecipes = async function () {
        const url = `api/recipes/${testMode}`;
        const resp = await fetch(url);
        const body = await resp.json();

        setRecipes(body);
    };

    //const goToRecipe = function () {

    //}

    const toggleTestMode = function () {
        setTestMode(!testMode);
        getAllRecipes();
    }


    useEffect(() => {
        getAllRecipes();
    }, []);

    var recipesContent = [];
    recipes.forEach(recipe => {
        recipesContent.push(
            //<a onClick={() => goToRecipe(recipe.id)}>{recipe.name}</a>
            <RecipeCard name={recipe.name} ingredients={recipe.ingredients} description={recipe.description} directions={recipe.directions} />
        );
    });

    return (
        <div id="recipes-container">
            <button onClick={toggleTestMode}>{buttonText}</button>
            <h3>Recipe List</h3>
            {recipesContent}
        </div>
    );
}

export default GetRecipes;