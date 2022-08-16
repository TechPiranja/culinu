import { Button, FormControl, InputLabel, MenuItem, Paper, Select, TextField } from "@mui/material";
import { useEffect, useState } from "react";
import { useSnackbar } from "notistack";
import MyDialog from "./MyDialog";
import { defaultService } from "../services/api";
import { updateRecipes } from "../redux/slices/recipeSlice";
import { useDispatch } from "react-redux";
import { Ingredient, Description } from "../types/recipe";
import CreateIngredient from "./CreateIngredient";

export default function CreateRecipe() {
	const [ingredients, setIngredients] = useState<Ingredient[]>([]);
	const [selectedIngredients, setSelectedIngredients] = useState<Ingredient[]>([]);
	const [description, setDescription] = useState<Description[]>([]);
	const [recipe, setRecipe] = useState<string>("");
	const [open, setOpen] = useState(false);
	const [error, setError] = useState(false);

	const dispatch = useDispatch();
	const { enqueueSnackbar } = useSnackbar();

	async function sendRequest() {
		if (recipe) {
			try {
				await defaultService
					.create("Recipe", {
						name: recipe,
						descriptions: description,
						ingredients: selectedIngredients,
					})
					.then(() => {
						enqueueSnackbar("Successfull", { variant: "success" });
						defaultService.getPrimitive("Recipe").then((result: any) => dispatch(updateRecipes(result.data)));
					});
			} catch {
				enqueueSnackbar("failedProcedure", { variant: "error" });
			}
			setError(false);
			return true;
		} else setError(true);
		return false;
	}

	useEffect(() => {
		defaultService.getPrimitive("Ingredient").then((result) => setIngredients({ ...ingredients, ...{ name: result.data } }));
		setError(false);
	}, []);

	return (
		<MyDialog ownButton noBackdrop showButton handleBtnTitle="save" title="Create recipe" saveItem={sendRequest} open={open} setOpen={setOpen} withActions iconName="SupportAgent">
			<Paper
				style={{
					height: "100%",
					maxWidth: 380,
					padding: 10,
					display: "flex",
					flexDirection: "column",
					justifyContent: "space-between",
				}}
				elevation={0}
			>
				<div style={{ display: "flex", gap: 15, flexDirection: "column" }}>
					<TextField label="Recipename" value={recipe} onChange={(e: any) => setRecipe(e.target.value)} />
					{/* <TextField
						multiline
						id="outlined-name"
						label="Ingredients"
						value={selectedIngredients.map((item: Ingredient) => item.name)}
						onChange={(e: any) => {
							let values = e.target.value.split(",");
							let mappedList = values.map((item: string) => {
								let ingredient = {} as Ingredient;
								ingredient.name = item;
								ingredient.amount = 0;
								ingredient.unit = "amount";
								return ingredient;
							});

							setSelectedIngredients(mappedList);
						}}
					/> */}
					<TextField
						multiline
						id="outlined-name"
						label="Cooking steps"
						value={description.map((item: Description) => item.description)}
						onChange={(e: any) => {
							let values = e.target.value.split(",");
							let mappedList = values.map((item: string) => {
								let ingredient = {} as Description;
								ingredient.description = item;
								return ingredient;
							});

							setDescription(mappedList);
						}}
					/>
					{selectedIngredients?.map((ingredient, index) => (
						<CreateIngredient key={index} ingredient={ingredient} updateIngredient={setSelectedIngredients} index={index} />
					))}
					<Button variant="contained" onClick={() => setSelectedIngredients([...selectedIngredients, {} as Ingredient])}>
						Add Ingredient
					</Button>
				</div>
			</Paper>
		</MyDialog>
	);
}
