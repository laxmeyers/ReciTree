<template>
    <div class="container position-relative">
        <img :src="recipe?.img" :alt="recipe?.name">
        <div class="position-absolute">
            <div class="d-flex">
                <h2>
                    {{ recipe?.name }}
                </h2>
                <img class="profile-img" :src="recipe?.creator.picture" :alt="recipe?.creator.name">
            </div>
        </div>

    </div>
</template>


<script>
import { Recipe } from '../models/Recipe.js';

export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped>
.profile-img {
    border-radius: 50%;
    height: 50px;
    width: 50px;
}
</style>
