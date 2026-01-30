// API слой (работа с backend)
export interface ResourceDto {
  id: string;
  name: string;
}

const BASE_URL = "http://localhost:5180"; // адрес API

export async function getResources(): Promise<ResourceDto[]> {
  const res = await fetch(`${BASE_URL}/resources`);
  return res.json();
}

export async function createResource(name: string): Promise<ResourceDto> {
  const res = await fetch(
    `${BASE_URL}/resources?name=${encodeURIComponent(name)}`,
    {
      method: "POST",
    },
  );

  return res.json();
}

export async function deleteResource(id: string): Promise<void> {
  await fetch(`${BASE_URL}/resources/${id}`, {
    method: "DELETE",
  });
}
