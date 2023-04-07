<template>
  <div class="container">
    <section class="masonry">
      <div v-for="r in recipes">
        <Recipe :recipe="r" />
      </div>
    </section>
  </div>
</template>

<script>
import { onMounted, computed } from 'vue';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import { AppState } from '../AppState.js';

export default {
  setup() {
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();

      } catch (error) {
        logger.error(error.message)
      }
    }
    onMounted(() => {
      getAllRecipes()
    })
    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss">
$gap: 1em;

.masonry {
  columns: 300px;
  column-gap: $gap;

  &>div {
    margin-top: $gap;
    display: inline-block;
  }
}
</style>
