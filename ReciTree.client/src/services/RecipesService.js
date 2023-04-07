import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {
    async getAllRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data.map(r => new Recipe(r))
        logger.log('[GET ALL RECIPES]', res.data)
    }
}
export const recipesService = new RecipesService()