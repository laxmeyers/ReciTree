<template>
    <div class="component">

        {{ recipe?.name }}
    </div>
</template>


<script>
import { onMounted, computed } from 'vue';
import { useRoute } from 'vue-router';
import { recipesService } from '../services/RecipesService';
import { AppState } from '../AppState';

export default {
    setup() {
        const route = useRoute();
        async function getThisRecipe() {
            try {
                const recipeId = route.params.recipeId
                await recipesService.getThisRecipe(recipeId)
            } catch (error) {
                logger.error(error.message)
            }
        }
        onMounted(() => {
            getThisRecipe()
        })
        return {
            recipe: computed(() => AppState.recipe)
        }
    }
}
</script>


<style lang="scss" scoped></style>