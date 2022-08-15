import { createSlice } from '@reduxjs/toolkit'

interface Recipe {
    id: number;
    name: string;
}

export const recipesSlice = createSlice({
    name: 'recipes',
    initialState: {
        recipes: [{ name: 'test' }, { name: 'dsfs' }] as Recipe[],
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