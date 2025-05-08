import React, { Component } from 'react';
import './AddRecipe.css';

export default class AddRecipe extends Component {
    constructor(props) {
        super(props)
    }

    submitRecipe = async () => {
        var name = document.getElementById("name").value;
        var description = document.getElementById("description").value;
        var ingredients = document.getElementById("ingredients").value;
        var directions = document.getElementById("directions").value;

        var recipe = { id: '', name: name, description: description, ingredients, ingredients, directions: directions };

            const config = {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(recipe)
            }

            // TO DO: this should have some kind of UI change when save complete
            const response = await fetch('api/recipes', config);
            return response;
    };

    render() {
        return (
            <div id="new-recipe-form">
                <h2>New Recipe</h2>
                <div className="elemRow">
                    <label htmlFor="name">Recipe Name</label>
                    <input id="name" type="text" placeholder="Give your recipe a name" />
                </div>
                <div className="elemRow">
                    <label htmlFor="description">Description</label>
                    <textarea id="description" placeholder="Share whatever makes this recipe special. Maybe it's a special memory, or a seasonal fruit you look forward to taking advantage of."></textarea>
                </div>
                <div className="elemRow">
                    <label htmlFor="ingredients">Ingredients</label>
                    <textarea id="ingredients" placeholder="1 C love, unsifted" rows="5" cols="35" />
                    <p>Include one ingredient and its measurement per line, please.</p>
                </div>
                <div className="elemRow">
                    <label htmlFor="directions">Directions</label>
                    <textarea id="directions" placeholder="Bake until delicious!" rows="8" cols="35" />
                </div>
                <button className="submitBtn" onClick={this.submitRecipe}>Submit Recipe</button>
            </div>
        );
    }
}