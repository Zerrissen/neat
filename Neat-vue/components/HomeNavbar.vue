<template>
    <nav>
        <ul>
            <li><a href="#">Home</a></li>
            <li>
                <NuxtLink to="/app">Application</NuxtLink>
            </li>
        </ul>
    </nav>
</template>

<script>
export default {
    name: 'HomeNavbar',
}
</script>

<style scoped>
nav {
    background-color: #f2f2f2;
    padding: 10px;
}

ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
}

li {
    display: inline-block;
    margin-right: 10px;
}

a {
    text-decoration: none;
    color: #333;
}
</style>
