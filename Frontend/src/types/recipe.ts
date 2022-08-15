export type Ingredient = {
    name: string;
    amount: number;
    unit: string;
};

export type Description = {
    description: string;
};

export interface Recipe {
    name: string;
    ingredients: Ingredient[],
    descriptions: Description[]
}