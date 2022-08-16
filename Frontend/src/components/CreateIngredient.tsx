import { TextField } from "@mui/material";
import { Ingredient } from "../types/recipe";

export default function CreateIngredient(props: any) {
	function handleUpdateIngredientName(value: string) {
		props.updateIngredient((prevState: Ingredient[]) => {
			return prevState.map((obj, i) => {
				return i === props.index ? { ...obj, name: value } : obj;
			});
		});
	}
	function handleUpdateIngredientAmount(value: string) {
		props.updateIngredient((prevState: Ingredient[]) => {
			return prevState.map((obj, i) => {
				return i === props.index ? { ...obj, amount: value } : obj;
			});
		});
	}
	function handleUpdateIngredientUnit(value: string) {
		props.updateIngredient((prevState: Ingredient[]) => {
			return prevState.map((obj, i) => {
				return i === props.index ? { ...obj, unit: value } : obj;
			});
		});
	}

	return (
		<div style={{ display: "flex", gap: 10 }}>
			<TextField fullWidth label="Name" value={props.ingredient.name} onChange={(e) => handleUpdateIngredientName(e.target.value)} />
			<TextField label="Amount" value={props.ingredient.amount} onChange={(e) => handleUpdateIngredientAmount(e.target.value)} />
			<TextField label="Unit" value={props.ingredient.unit} onChange={(e) => handleUpdateIngredientUnit(e.target.value)} />
		</div>
	);
}
