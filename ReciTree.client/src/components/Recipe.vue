<template>
    <div class="container position-relative">
        <img class="img-fluid rounded" :src="recipe?.img" :alt="recipe?.name">
        <div class="over-img">
            <h2>
                {{ recipe?.name }}
            </h2>
            <img class="profile-img" :src="recipe?.creator.picture" :alt="recipe?.creator.name">
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

.over-img {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding-left: 15px;
    padding-right: 15px;
    padding-bottom: 5px;
    color: white;
    text-shadow: 0px 2px 0px black;

}
</style>
