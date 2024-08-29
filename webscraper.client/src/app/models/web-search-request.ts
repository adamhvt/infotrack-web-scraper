import { WebSearchProvider } from "./web-search-provider";

export interface WebSearchRequest {
    searchExpression: string;
    searchProvider: WebSearchProvider;
    isAdHoc?: boolean;
}