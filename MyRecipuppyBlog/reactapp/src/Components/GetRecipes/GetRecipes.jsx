import React, { useState, useEffect } from 'react';
import './GetRecipes.css';

function GetRecipes() {

    const [recipes, setRecipes] = useState([]);
    const [testMode, setTestMode] = useState(true);
    const buttonText = `Test mode: ${testMode ? "ON" : "OFF"}`;

    const getAllRecipes = async function () {
        if (testMode) {
            var fakeRecipes = [
                { name: "apple", description: "just an apple", ingredients: "apple", directions: "eat apple" },
                { name: "toast", description: "a breakfast fave", ingredients: "bread\npeanut butter", directions: "toast bread\ntop with peanut butter\nenjoy!" },
                { name: "yogurt bowl", description: "my favorite breakfasttime treat", ingredients: "vanilla yogurt\ngranola\n1 banana\npb fit", directions: "Combine vanilla yogurt and some pb fit in a bowl. Top with banana slices and granola. Drizzle with pb fit mixed with water. Eat!"},
            ];

            setRecipes(fakeRecipes);
        }
        else {
            const url = "api/recipes";
            const resp = await fetch(url);
            const body = await resp.json();

            setRecipes(body);
        }
    };

    const toggleTestMode = function () {
        setTestMode(!testMode);
    }


    useEffect(() => {
        getAllRecipes();
    }, []);

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

    return (
        <div id="recipes-container">
            <button onClick={toggleTestMode}>{buttonText}</button>
            <h3>Recipe List</h3>
            {recipesContent}
        </div>
    );
}

export default GetRecipes;