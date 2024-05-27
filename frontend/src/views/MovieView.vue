<script setup lang="ts">
  import {Search, Bell} from "lucide-vue-next";

</script>

<template>
  <div :class="$style.container">
    <header>
      <p>Movies</p>
      <div :class="$style.tabsContainer">
        <ul :class="$style.tabs">
          <li>Home</li>
          <li>Movies & Shows</li>
          <li>Support</li>
          <li>Subscriptions</li>
        </ul>
      </div>
      <div :class="$style.icons">
        <Search />
        <Bell />
      </div>
    </header>
  </div>

</template>

<style module>
  header {
    background-color:  #141414;
    color: white;
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  header p {
    font-family: "Arial Black", Helvetica, sans-serif;
    margin: 0;
    font-size: x-large;
  }

  .container {
    margin-left: 10%;
    margin-right: 10%;
  }

  .icons {
    display: flex;
    align-items: center;
  }

  .tabs {
    display: flex;
    flex-direction: row;
    list-style: none;
    padding: 0;
    margin: 0;
    font-family: "Arial Rounded MT Bold", Helvetica, sans-serif;
    font-size: 14px;
    font-weight: 100;
  }

  .tabs * {
    margin: 5px;
  }

  .tabsContainer {
    border: #202020 3px solid;
    background-color: #0F0F0F;
    border-radius: 10px;
    margin: 10px 0;
    padding: 10px 10px;
  }

</style>