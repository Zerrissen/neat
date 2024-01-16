<template>
    <AppNavbar />

    <p class="text-xl">Data from Database</p>

    <div class="mt-5">
        <UButton @click="startAssetCreate()">Add Asset</UButton>
    </div>

    <USlideover v-model="formSlideoverIsOpen" :ui="{ width: 'w-screen max-w-4xl' }">
        <form @submit.prevent="submitForm">
            <label>
                <span>Barcode</span>
                <UInput v-model="formData.id" />
            </label>

            <label>
                <span>Asset Type</span>
                <USelect v-model="formData.assetTypeName" :options="assetTypes" />
            </label>

            <label>
                <span>Make</span>
                <UInput v-model="formData.make" />
            </label>

            <label>
                <span>Model</span>
                <UInput v-model="formData.model" />
            </label>

            <label>
                <span>Serial Number</span>
                <UInput v-model="formData.serial" />
            </label>

            <label>
                <span>Part Number</span>
                <UInput v-model="formData.partNumber" />
            </label>

            <label>
                <span>Status</span>
                <USelect v-model="formData.statusName" :options="statuses" />
            </label>

            <label>
                <span>Location</span>
                <USelect v-model="formData.locationName" :options="locations" />
            </label>

            <label>
                <span>Condition</span>
                <USelect v-model="formData.conditionName" :options="conditions" />
            </label>

            <label>
                <span>Purchase Price</span>
                <UInput v-model="formData.price" />
            </label>

            <label>
                <span>Purchase Date</span>
                <UInput v-model="purchaseDateString" />
            </label>

            <label>
                <span>Warranty Expiration</span>
                <UInput v-model="warrantyExpirationString" />
            </label>

            <label>
                <span>Notes</span>
                <UInput v-model="formData.notes" />
            </label>

            <UButton type="submit">Submit</UButton>
        </form>
    </USlideover>

    <div class="flex h-screen mt-5">
        <UTable :columns=dataColumns :rows=apiData @select="selectAsset" />
    </div>
</template>

<script lang="ts">

import AssetService from '~/services/asset-service';
import PropertyService from '~/services/property-service';
import AppNavbar from '~/components/AppNavbar.vue';

import type Asset from '@/types/Asset'

// * Define services
const assetService = new AssetService();
const propertyService = new PropertyService();

export default {
    name: 'AppIndex',
    components: {
        AppNavbar,
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
            slideoverIsOpen: ref(false),
            formSlideoverIsOpen: ref(false),
            assetTypes: [] as { value: string; }[],
            statuses: [] as { value: string; }[],
            locations: [] as { value: string; }[],
            conditions: [] as { value: string; }[],
            formData: {
                id: 0,
                assetTypeName: '',
                make: '',
                model: '',
                serial: '',
                partNumber: '',
                statusName: '',
                locationName: '',
                conditionName: '',
                price: 0,
                purchaseDate: new Date(),
                warrantyExpiration: new Date(),
                notes: '',
                createdAt: new Date(),
                updatedAt: new Date()
            } as Asset,
        }
    },
    methods: {
        selectAsset(asset: Asset) {
            // Nuxt-link to /assets/:id
            this.$router.push(`/app/assets/${asset.id}`);
        },
        startAssetCreate() {
            this.formSlideoverIsOpen = true;
        },
        submitForm() {
            assetService.createAsset(this.formData)
                .then((response) => {
                    this.apiData.push(response);
                    this.formSlideoverIsOpen = false;
                }).catch((error) => {
                    console.log(error.message)
                });
        },
        fetchAssetTypes() {
            propertyService.getAllAssetTypes()
                .then((response: { assetTypeName: string }[]) => {
                    this.assetTypes = response.map(assetType => ({
                        value: assetType.assetTypeName
                    }));
                    console.log(this.assetTypes)
                }).catch((error) => {
                    console.log(error.message)
                });
        },
        fetchStatuses() {
            propertyService.getAllStatuses()
                .then((response: { statusName: string }[]) => {
                    this.statuses = response.map(status => ({
                        value: status.statusName
                    }));
                }).catch((error) => {
                    console.log(error.message)
                });
        },
        fetchLocations() {
            propertyService.getAllLocations()
                .then((response: { locationName: string }[]) => {
                    this.locations = response.map(location => ({
                        value: location.locationName
                    }));
                }).catch((error) => {
                    console.log(error.message)
                });
        },

        fetchConditions() {
            propertyService.getAllConditions()
                .then((response: { conditionName: string }[]) => {
                    this.conditions = response.map(condition => ({
                        value: condition.conditionName
                    }));
                }).catch((error) => {
                    console.log(error.message)
                });
        },
    },
    created() {
        assetService.getAllAssets()
            .then((response) => {
                this.apiData = response;
            }).catch((error) => {
                console.log(error.message)
            });
        this.fetchStatuses();
        this.fetchLocations();
        this.fetchConditions();
        this.fetchAssetTypes();
    },
    computed: {
        purchaseDateString: {
            get() {
                return this.formData.purchaseDate.toISOString();
            },
            set(value: string) {
                this.formData.purchaseDate = new Date(value);
            },
        },
        warrantyExpirationString: {
            get() {
                return this.formData.warrantyExpiration.toISOString();
            },
            set(value: string) {
                this.formData.warrantyExpiration = new Date(value);
            },
        },
    }
}
</script>
