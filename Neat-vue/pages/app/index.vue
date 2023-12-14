<template>
    <AppNavbar />
    <p class="text-xl">Data from Database</p>
    <div class="flex h-screen mt-5">

        <UTable :columns=dataColumns :rows=apiData @select="selectAsset" />

        <USlideover v-model="slideoverIsOpen" v-if="selectedAssetDetails" :ui="{ width: 'w-screen max-w-4xl' }">
            <div>
                <p class="text-xl">Barcode: {{ selectedAssetDetails.id }}</p>
                <p class="text-xl">Asset Type: {{ selectedAssetDetails.assetTypeName }}</p>
                <p class="text-xl">Model: {{ selectedAssetDetails.make }} {{ selectedAssetDetails.model }}</p>
                <p class="text-xl">Serial Number: {{ selectedAssetDetails.serial }}</p>
                <p class="text-xl">Status: {{ selectedAssetDetails.statusName }}</p>
                <p class="text-xl">Location: {{ selectedAssetDetails.locationName }}</p>
                <p class="text-xl">Condition: {{ selectedAssetDetails.conditionName }}</p>
                <p class="text-xl">Purchase Price: {{ selectedAssetDetails.price }}</p>
                <p class="text-xl">Purchase Date: {{ selectedAssetDetails.purchaseDate }}</p>
                <p class="text-xl">Warranty expiry: {{ selectedAssetDetails.warrantyExpiration }}</p>
                <p class="text-xl">Notes: {{ selectedAssetDetails.notes }}</p>
            </div>
        </USlideover>
    </div>
</template>

<script lang="ts">
import AssetService from '~/services/asset-service';
import AppNavbar from '~/components/AppNavbar.vue';
import AppAssetListItem from '~/components/AppAssetListItem.vue';

import type Asset from '@/types/Asset'

const assetService = new AssetService();

export default {
    name: 'AppIndex',
    components: {
        AppNavbar,
        AppAssetListItem
    },
    data() {
        return {
            apiData: [] as Asset[],
            dataColumns: [
                { key: 'id', label: 'Asset ID' },
                { key: 'assetTypeName', label: 'Asset Type' },
                { key: 'make', label: 'Make' },
                { key: 'model', label: 'Model' },
                { key: 'statusName', label: 'Status' },
                { key: 'locationName', label: 'Location' },
                { key: 'conditionName', label: 'Last known condition' }

            ],
            selectedAssetDetails: null as Asset | null,
            slideoverIsOpen: ref(false),
            selectedRow: ref([])
        }
    },
    methods: {
        selectAsset(asset: Asset) {
            assetService.getAssetById(asset.id)
                .then((response) => {
                    this.selectedAssetDetails = response;
                }).catch((error) => {
                    console.log(error.message)
                });

            // this.selectedAsset = asset;
            this.slideoverIsOpen = true;
        }
    },
    created() {
        assetService.getAllAssets()
            .then((response) => {
                this.apiData = response;
            }).catch((error) => {
                console.log(error.message)
            });
    }
}
</script>
