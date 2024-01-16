import axios from 'axios';
import type IAsset from '@/types/Asset';

export default class AssetService {
    public async getAllAssets(): Promise<IAsset[]> {
        const config = useRuntimeConfig();
        let result = await axios.get(`${config.public.apiUrl}/assets/`);
        return result.data;
    }

    public async getAssetById(id: number): Promise<IAsset> {
        const config = useRuntimeConfig();
        let result = await axios.get(`${config.public.apiUrl}/assets/${id}`);
        return result.data;
    }

    public async createAsset(asset: IAsset): Promise<IAsset> {
        const config = useRuntimeConfig();
        let result = await axios.post(`${config.public.apiUrl}/assets/`, asset);
        return result.data;
    }
}