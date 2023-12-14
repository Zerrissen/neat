<template>
    <div class="border rounded p-4 mb-2 w-auto hover:bg-gray-700 duration-100">
        <p>{{ title }}</p>
        <p>{{ description }}</p>
    </div>
</template>

<script>
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'AppAssetList',
    props: {
        title: {
            type: Number,
            required: true
        },
        description: {
            type: String,
            default: 'No description provided'
        },
    },
});
</script>