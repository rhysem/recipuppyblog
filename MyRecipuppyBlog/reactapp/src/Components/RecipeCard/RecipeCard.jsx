import React from 'react';
import './RecipeCard.css';

function RecipeCard({ name, ingredients, description, directions }) {
    var ingredientsList = [];

    ingredients.split('\n').forEach(ingredient => {
        ingredientsList.push(
            <li className="ingredient">
                {ingredient}
            </li>
        );
    });


    return (
        <div className="recipe-card">
            <h5 className="name">{name}</h5>
            {ingredientsList.length > 0 &&
                <ul className="ingredients-list">
                    {ingredientsList}
                </ul>
            }
            <p className="description">{description}</p>
            <p className="directions">{directions}</p>
        </div>
    );
}

export default RecipeCard;