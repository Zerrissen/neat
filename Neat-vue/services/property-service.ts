import axios from 'axios';

export default class AssetTypeService {

    // * GET /api/properties/statuses
    public async getAllStatuses(): Promise<[]> {
        const config = useRuntimeConfig();
        let result = await axios.get(`${config.public.apiUrl}/properties/statuses/`);
        return result.data;
    }

    // * GET /api/properties/conditions
    public async getAllConditions(): Promise<[]> {
        const config = useRuntimeConfig();
        let result = await axios.get(`${config.public.apiUrl}/properties/conditions/`);
        return result.data;
    }

    // * GET /api/properties/locations
    public async getAllLocations(): Promise<[]> {
        const config = useRuntimeConfig();
        let result = await axios.get(`${config.public.apiUrl}/properties/locations/`);
        return result.data;
    }

    // * GET /api/properties/asset-types
    public async getAllAssetTypes(): Promise<[]> {
        const config = useRuntimeConfig();
        let result = await axios.get(`${config.public.apiUrl}/properties/asset-types/`);
        return result.data;
    }
}