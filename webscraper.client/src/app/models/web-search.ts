import { WebSearchProvider } from "./web-search-provider";
import { WebSearchResult } from "./web-search-result";

export interface WebSearch {
    id: string;
    searchExpression: string;
    searchProvider: WebSearchProvider;
    createdAt: string;
    webSearchResults: WebSearchResult[];
}