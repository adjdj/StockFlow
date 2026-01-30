import { useEffect, useState } from "react";
import { createResource, deleteResource, getResources } from "../api/resources";
import type { ResourceDto } from "../api/resources";
import { ResourceTable } from "../components/ResourceTable";

export function ResourcesPage() {
  const [resources, setResources] = useState<ResourceDto[]>([]);
  const [name, setName] = useState("");

  async function load() {
    setResources(await getResources());
  }

  useEffect(() => {
    //load();
    Promise.resolve().then(load);
  }, []);

  async function onAdd() {
    if (!name.trim()) return;

    await createResource(name);
    setName("");
    await load();
  }

  async function onDelete(id: string) {
    await deleteResource(id);
    await load();
  }

  return (
    <div style={{ padding: 20 }}>
      <h1>Ресурсы</h1>

      <div style={{ marginBottom: 16 }}>
        <input
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Название ресурса"
        />
        <button onClick={onAdd}>Добавить</button>
      </div>

      <ResourceTable resources={resources} onDelete={onDelete} />
    </div>
  );
}
