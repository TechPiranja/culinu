import { createSlice } from '@reduxjs/toolkit'
import { Recipe } from '../../types/recipe';

export const recipesSlice = createSlice({
    name: 'recipes',
    initialState: {
        recipes: [] as Recipe[],
        selectedRecipe: {} as Recipe
    },
    reducers: {
        updateRecipes: (state, action) => {
            state.recipes = action.payload;
        },
        updateSelectedRecipe: (state, action) => {
            state.selectedRecipe = action.payload
        },
    },
})

// Action creators are generated for each case reducer function
export const { updateRecipes, updateSelectedRecipe } = recipesSlice.actions

export default recipesSlice.reducer