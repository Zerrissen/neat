<template>
    <UTabs>
        <UTab v-for="asset in $store.state.openedAssets" :key="asset.id" :label="`Asset ${asset.id}`">
            <nuxt-link :to="`/app/assets/${tab.id}`">{{ tab.name }}</nuxt-link>
            <button @click="removeTab(tab)">Close</button>
            <router-view />
        </UTab>
    </UTabs>
</template>
  
<script>
export default {
    name: 'AppAssetNavbar',
};
</script>