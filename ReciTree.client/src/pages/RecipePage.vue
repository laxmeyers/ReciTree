<template>
    <div v-if="recipe">
        <div class="container-fluid">
            <div class="row p-3">

                <div class="col-md-12 text-center">
                    <img :src="recipe.img" class="elevation-5 " alt="">
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="card elevation-2">
                        <div class="card-body">
                            <h2>{{ recipe.instructions }}</h2>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card elevation-2">
                        <div class="card-body">
                            <h2>ingredients here</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>


<script>
import { onMounted, computed, onUnmounted } from 'vue';
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
        onUnmounted(() => {
            AppState.recipe = []
        })
        return {
            recipe: computed(() => AppState.recipe)
        }
    }
}
</script>


<style lang="scss" scoped></style>