export interface State<T> {
    status: 'idle'| 'loading' | 'succeeded' | 'failed',
    data: T[],
    error: string | null
}