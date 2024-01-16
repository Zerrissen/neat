<template>
    <div v-if="asset">
        <h1>{{ asset.id }}</h1>
        <p>{{ asset.make + ' ' + asset.model }}</p>
    </div>
    <div v-else>Loading...</div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'AppAssetDetails',
    data() {
        return {
            asset: null,
        };
    },
    methods: {
        async fetchData() {
            const config = useRuntimeConfig();
            const { data } = await axios.get(`${config.public.apiUrl}/assets/${this.$route.params.id}`);
            this.asset = data;
        }
    },
    watch: {
        '$route.params.id': {
            immediate: true,
            handler() {
                this.fetchData();
            },
        },
    },
};
</script>